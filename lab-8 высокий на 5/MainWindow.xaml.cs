using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CircularDoublyLinkedList
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        class Node
        {
            public double Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(double data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }
        class CircularDoublyLinkedList
        {
            private Node Head;
            private Node Tail;

            public CircularDoublyLinkedList()
            {
                Head = null;
                Tail = null;
            }
            public void Insert(double data)
            {
                Node newNode = new Node(data);
                if (Head == null)
                {
                    Head = newNode;
                    Tail = newNode;
                    newNode.Next = Head;
                    newNode.Prev = Head;
                }
                else
                {
                    Tail.Next = newNode;
                    newNode.Prev = Tail;
                    newNode.Next = Head;
                    Head.Prev = newNode;
                    Tail = newNode;
                }
            }
            public void RemoveBeforeThrees()
            {
                Node current = Head;
                do
                {
                    if (current.Data == 3)
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    current = current.Next;
                } while (current != Head);
            }
            public string Display()
            {
                string result = "";
                Node current = Head
                    ;
                do
                {
                    result += current.Data + " ";
                    current = current.Next;
                } while (current != Head);
                return result;
            }
        }

        private void CreateListButton_Click(object sender, RoutedEventArgs e)
        {
            CircularDoublyLinkedList list = new CircularDoublyLinkedList();
            list.Insert(2);
            list.Insert(3);
            list.Insert(5);
            list.Insert(7);
            list.Insert(4);
            list.RemoveBeforeThrees();
            ResultTextBox.Text = list.Display();
        }
    }
}
