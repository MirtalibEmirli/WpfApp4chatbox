using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4;

public
    class Message1
{


    public Message1() { }
    public string? _Text { get; set; }
    public DateTime? _Time { get; set; }
    public Message1(string text, DateTime time)
    {
        _Text = text;
        _Time = time;
    }

    public override string ToString()
    {
        return $"{_Time.Value.Hour}:{_Time.Value.Minute}  {_Text}";
    }

}
