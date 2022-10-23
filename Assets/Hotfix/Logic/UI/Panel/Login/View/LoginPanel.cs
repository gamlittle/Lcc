﻿using LccModel;

namespace LccHotfix
{
    public class LoginPanel : APanelView<LoginModel>
    {
        public override void InitView(LoginModel viewModel)
        {
            LogUtil.Log("InitView第一个执行的函数");
            LogUtil.Log("负责给viewModel的字段绑定");
            //参考
            //Binding<bool>(nameof(viewModel.isLoading), IsLoading);
            //public void IsLoading(bool oldValue, bool newValue)
            //{
            //}
        }
        public override void Binding(LoginModel oldValue, LoginModel newValue)
        {
            LogUtil.Log("Binding第二个执行的函数");
            LogUtil.Log("LoginModel第一次初始化时会触发，LoginModel绑定切换的时候会调用");
        }


        public override void OnInitData(Panel panel)
        {
            LogUtil.Log("OnInitData第三个执行的函数");
            panel.data.type = UIType.Normal;
        }

        public override void OnInitComponent(Panel panel)
        {
            LogUtil.Log("OnInitComponent第四个执行的函数");

        }
        public override void OnRegisterUIEvent(Panel panel)
        {
            LogUtil.Log("OnRegisterUIEvent第五个执行的函数");
        }


        public override void OnShow(Panel panel, AObjectBase contextData = null)
        {
            LogUtil.Log("OnShow第六个执行的函数");

 
        }

        public override void OnHide(Panel panel)
        {
            LogUtil.Log("OnHide");
        }

        public override void BeforeUnload(Panel panel)
        {
            LogUtil.Log("BeforeUnload");
        }


    }
}