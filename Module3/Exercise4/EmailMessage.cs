namespace Exercise4
{
    public class EmailMessage
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }

        public EmailMessage(string title, string content, string from, string to)
        {
            if (string.IsNullOrEmpty(title)) 
            {  
                throw new ArgumentNullException("title"); 
            }

            if (string.IsNullOrEmpty(content)) 
            {  
                throw new ArgumentNullException("content"); 
            }

            if (string.IsNullOrEmpty(from)) 
            { 
                throw new ArgumentNullException("from"); 
            }

            if (string.IsNullOrEmpty(to)) 
            {  
                throw new ArgumentNullException("to"); 
            }

            Title = title;
            Content = content;
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return $"Title {Title}; From {From}; To {To}";
        }
    }
}
