using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace LccModel
{
    public partial class Launcher
    {

        ////下载公告内容，string类型，需要解析出来
        ////一条公告：标题&内容&索引&类型
        ////多条公告用|连接
        ////示例：000&0000&0000&000|000&0000&0000&000|000&0000&0000&000|
        public string AnnouncementSave;
        public bool NoticeSucc;

        public string NoticeBoardSave;
        public bool NoticeBoardSucc;
        public IEnumerator GetNotice()
        {
            NoticeSucc = false;
            AnnouncementSave = "";
            string url = $"{Launcher.Instance.noticeUrl}/{Launcher.GameConfig.channel}/{Launcher.Instance.curLanguage}/notice.txt";
            Debug.Log("GetNoticeBoard url=" + url);

            UnityWebRequest web = UnityWebRequest.Get(url);
            web.SetRequestHeader("pragma", "no-cache");
            web.SetRequestHeader("Cache-Control", "no-cache");
#if UNITY_EDITOR
            web.timeout = 2;
#else
		    web.timeout = 20;
#endif

            yield return web.SendWebRequest();

            if (!string.IsNullOrEmpty(web.error))
            {
                web.Dispose();
                web = UnityWebRequest.Get(url);
                web.timeout = 20;
                yield return web.SendWebRequest();
            }

            if (!string.IsNullOrEmpty(web.error))
            {
            }
            else
            {
                string text = web.downloadHandler.text;
                AnnouncementSave = text;
                NoticeSucc = true;
            }
        }

        public bool CheckNoticeBoard()
        {
            if (!string.IsNullOrEmpty(Launcher.Instance.NoticeBoardSave) && Launcher.Instance.NoticeBoardSucc && !Launcher.Instance.IsAuditServer())
            {
                //停服了
                return true;
            }
            return false;
        }

        public IEnumerator GetNoticeBoard()
        {
            NoticeBoardSucc = false;
            NoticeBoardSave = "";
            string url = $"{Launcher.Instance.noticeUrl}/{Launcher.GameConfig.channel}/{Launcher.Instance.curLanguage}/noticeBoard.txt";
            Debug.Log("GetNoticeBoard url=" + url);

            UnityWebRequest web = UnityWebRequest.Get(url);
            web.SetRequestHeader("pragma", "no-cache");
            web.SetRequestHeader("Cache-Control", "no-cache");
#if UNITY_EDITOR
            web.timeout = 2;
#else
		    web.timeout = 20;
#endif

            yield return web.SendWebRequest();

            if (!string.IsNullOrEmpty(web.error))
            {
                web.Dispose();
                web = UnityWebRequest.Get(url);
                web.timeout = 20;
                yield return web.SendWebRequest();
            }

            if (!string.IsNullOrEmpty(web.error))
            {
            }
            else
            {
                string text = web.downloadHandler.text;
                NoticeBoardSave = text;
                NoticeBoardSucc = true;
            }
        }

    }
}