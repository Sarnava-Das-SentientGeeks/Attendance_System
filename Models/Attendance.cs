
using System.ComponentModel.DataAnnotations;


public class Attendance
{
    public int Id {  get; set; }

    [Required]
    public string StudentName {  get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public bool IsPresent {  get; set; }
}
