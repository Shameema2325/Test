namespace Test.Models
{
    public class User
    {
        public int Id { get; set; }                  
        public string? Name { get; set; }            
        public int Age { get; set; }

        
        public string? PhoneNumber { get; set; }      
        public DateTime DateOfBirth { get; set; }    
        public DateTime Time { get; set; }           
        public bool IsAvailable { get; set; }        
        public string? Qualification { get; set; }    
        public string? Emirates { get; set; }         
    }
}