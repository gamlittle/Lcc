﻿using System;

namespace Model
{
    public class ViewBase<T> : ObjectBase, IView<T> where T : ViewModelBase
    {
        public bool init;
        public Binding<T> binding;
        protected DataBinder<T> dataBinder;
        public ViewBase()
        {
            ViewModel = Activator.CreateInstance<T>();
        }
        public T ViewModel
        {
            get
            {
                return binding.Value;
            }
            set
            {
                if (!init)
                {
                    InitView();
                }
                binding.Value = value;
            }
        }
        public virtual void InitView()
        {
            init = true;
            binding = new Binding<T>();
            dataBinder = new DataBinder<T>();
            binding.OnValueChange += Binding;
        }
        public virtual void Binding(T oldValue, T newValue)
        {
            dataBinder.UnBind(oldValue);
            dataBinder.Bind(newValue);
        }
        public virtual void ClosePanel()
        {
            PanelType type = GameUtil.ConvertStringToPanelType(GetType().Name);
            PanelManager.Instance.ClosePanel(type);
        }
        public virtual void ClearPanel()
        {
            PanelType type = GameUtil.ConvertStringToPanelType(GetType().Name);
            PanelManager.Instance.ClearPanel(type);
        }
    }
}