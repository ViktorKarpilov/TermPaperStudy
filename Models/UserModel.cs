namespace TermPaper.Models
{
    public class User
    {
        public int ID{get;set;}
        public string Username{get;set;}

        public string Email{get;set;} 
        
        public string Password{get;set;}

        public User(string Username,string Email,string Password){
            this.Username = Username;
            this.Email = Email;
            this.Password = DataOperation.ComputeSha256Hash(Password);
        }

        public bool ComparePassword(string Password){
            if(this.Password == DataOperation.ComputeSha256Hash(DataOperation.ComputeSha256Hash(Password))){
                return true;
            }
            return false;
        }
    }
}