namespace TermPaper.Models
{
    public class CommentModel
    {
        public int Id{get;set;}
        public string Author{get;set;}
        
        public string Comment{get;set;}

        public CommentModel(string Author,string Comment){
            this.Author = Author;
            this.Comment = Comment;
        }
    }
}