using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Usercs
    {
            public int Id { get; set; }
            public string? TextBox { get; set; }
            public int NumericBox { get; set; }
            public string? MaskedBox { get; set; }
            public DateTime DatePicker { get; set; }
            public DateTime DateTimePicker { get; set; }
            public bool SwitchInput { get; set; }
            public string? ComboBox { get; set; }
    }
}
