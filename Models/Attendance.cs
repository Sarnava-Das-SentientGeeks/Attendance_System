
using System.ComponentModel.DataAnnotations;
//This allows to use validation attributes 
//Without this [Required],[StringLength],[Range],[Key] etc won't work


public class Attendance
{
 
    public int Id {  get; set; }
   //EF core automatically recognizes it as the Primary key
   //In SQL Server, this automatically becomes Id INT PRIMARY KEY IDENTITY(1,1)
   //We don't need to use [Key] since EF Core uses naming convention
    
    [Required]
    public string StudentName {  get; set; }
    //This field cannot be null i.e database column will not be null and model validation will fail if empty

    [Required]
    public DateTime Date { get; set; }
    //This automatically becomes Date DATETIME NOT NULL
    //If user submits form without Date then ModelState.IsValid will return false

    [Required]
    public bool IsPresent {  get; set; }
}
