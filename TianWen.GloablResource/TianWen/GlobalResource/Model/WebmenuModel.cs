namespace TianWen.GlobalResource.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class WebmenuModel
    {
        [CompilerGenerated]
        private IList<WebmenuModel> ilist_0;
        [CompilerGenerated]
        private string string_0;
        [CompilerGenerated]
        private string string_1;
        [CompilerGenerated]
        private string string_2;
        [CompilerGenerated]
        private string string_3;
        [CompilerGenerated]
        private string string_4;
        [CompilerGenerated]
        private string string_5;

        public WebmenuModel()
        {
            this.Childs = new List<WebmenuModel>();
        }

        public IList<WebmenuModel> Childs
        {
            [CompilerGenerated]
            get
            {
                return this.ilist_0;
            }
            [CompilerGenerated]
            set
            {
                this.ilist_0 = value;
            }
        }

        public string Href
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

        public string Id
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

        public string ImgUrl
        {
            [CompilerGenerated]
            get
            {
                return this.string_4;
            }
            [CompilerGenerated]
            set
            {
                this.string_4 = value;
            }
        }

        public string Name
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

        public string Remark
        {
            [CompilerGenerated]
            get
            {
                return this.string_5;
            }
            [CompilerGenerated]
            set
            {
                this.string_5 = value;
            }
        }

        public string Target
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
    }
}

