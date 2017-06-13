namespace TianWen.Logger
{
    using System;
    using System.Runtime.CompilerServices;

    public class TianWenMessage
    {
        [CompilerGenerated]
        private string string_0;
        [CompilerGenerated]
        private string string_1;
        [CompilerGenerated]
        private string string_2;
        [CompilerGenerated]
        private string string_3;

        public TianWenMessage()
        {
        }

        public TianWenMessage(string userName, string operation, string topic, string description)
        {
            this.UserName = userName;
            this.Operation = operation;
            this.Topic = topic;
            this.Description = description;
        }

        public override string ToString()
        {
            return (this.UserName + "\r\n" + this.Operation + "\r\n" + this.Topic + "\r\n" + this.Description);
        }

        public string Description
        {
            [CompilerGenerated]
            get
            {
                return this.string_3;
            }
            [CompilerGenerated]
            set
            {
                this.string_3 = value;
            }
        }

        public string Operation
        {
            [CompilerGenerated]
            get
            {
                return this.string_1;
            }
            [CompilerGenerated]
            set
            {
                this.string_1 = value;
            }
        }

        public string Topic
        {
            [CompilerGenerated]
            get
            {
                return this.string_2;
            }
            [CompilerGenerated]
            set
            {
                this.string_2 = value;
            }
        }

        public string UserName
        {
            [CompilerGenerated]
            get
            {
                return this.string_0;
            }
            [CompilerGenerated]
            set
            {
                this.string_0 = value;
            }
        }
    }
}

