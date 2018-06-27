
namespace SimpleMvc
{
    public class Facade
    {
        protected IController mController;

        protected Facade()
        {
            InitFramework();
        }

        protected virtual void InitFramework()
        {
            if (mController != null) return;
            mController = Controller.Instance;
        }

        public virtual bool Has(string commandName)
        {
            return mController.Has(commandName);
        }

        /// <summary>
        /// 发送信息，如果有监听该信息的View就会执行其中的OnMessage方法
        /// </summary>
        public void SendMessage(string message, object body = null)
        {
            mController.Execute(new Message(message, body));
        }

        /// <summary>
        /// 获取Model实例对象，如果没有被移除，每次获取到的都是同一实例
        /// </summary>
        public static T GetModel<T>() where T : IModel
        {
            return Model.GetModel<T>();
        }

        public static void RemoveModel<T>() where T : IModel
        {
            Model.RemoveModel<T>();
        }

    }

}

