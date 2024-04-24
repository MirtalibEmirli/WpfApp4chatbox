using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using WpfApp4;

namespace WpfDatabinding
{
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty MessagesProperty =
            DependencyProperty.Register("Messages", typeof(ObservableCollection<Message1>), typeof(MainWindow), new PropertyMetadata(null));

        public ObservableCollection<Message1> Messages
        {
            get { return (ObservableCollection<Message1>)GetValue(MessagesProperty); }
            set { SetValue(MessagesProperty, value); }
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadMessages();
            DataContext = this;
        }

        private void LoadMessages()
        {
            
                string datas = File.ReadAllText("../../../msg.json");
                Messages = JsonSerializer.Deserialize<ObservableCollection<Message1>>(datas);
           
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Messages.Add(new Message1(txtbox.Text, DateTime.Now));
            SaveMessages();
        }

        private void SaveMessages()
        {
            string messages = JsonSerializer.Serialize(Messages);
                File.WriteAllText("../../../msg.json", messages);
            
        }
    }
}
