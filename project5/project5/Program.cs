using System.Threading.Channels;

internal class Program
{
	class Student
	{
        public Student()
        {
            Console.WriteLine("enter ID");
            Id=int.Parse(Console.ReadLine());
			Console.WriteLine("enter Name");
			Name = Console.ReadLine();
			
			do
			{
				Console.WriteLine("enter Exame1");
				Exame1 = double.Parse(Console.ReadLine());
			} while (Exame1>100||Exame1<0);
			do
			{
			Console.WriteLine("enter Exame2");
			Exame2 =double.Parse(Console.ReadLine());
			} while (Exame2 > 100 || Exame2 < 0);
			Dugre();
		}
        public enum Avreg_dugre
		{
			Fail,
			Good,
			VeryGood,
			Excellent

		}
		Avreg_dugre dugre;
		public int Id { get; set; }
		public string Name { get; set; }
        public double Exame1 { get; set; }
		public double Exame2 { get; set; }
		public double Avreg { get { return (Exame1 + Exame2) / 2; } }
		public void Dugre()
		{
			double res = Avreg;
			{
				if (res<50)
				{
					dugre = Avreg_dugre.Fail;
				}
				else if (res<=60) { dugre = Avreg_dugre.Good; }
				else if (res <= 80) { dugre = Avreg_dugre.VeryGood; }
				else if (res <= 100) { dugre = Avreg_dugre.Excellent; }
			} 
		}
		public override string ToString()
		{
			return $"ID: {Id}\n Name: {Name}\n Avreg: {Avreg}\n dugre: {dugre}";
		}

	}
	class Node
	{
		Student data;
		Node next;
        public Student Data { set { data = value; }get { return data; } }
        public Node Next { get; set; }
        public Node(Student data)
        {
         this.data = data;   
        }

    }
	class List
	{
		Node First;
		public void Add(Student data)
		{
			Node t = new Node(data);
			if (First == null || First.Data.Avreg > data.Avreg)
			{
				t.Next = First;
				First = t;
				Console.WriteLine("Add complute");
				return;
			}

			Node move = First;
			while (move.Next != null && move.Next.Data.Avreg < data.Avreg)
			{
				move = move.Next;

			}
			t.Next = move.Next;
			move.Next = t;
			Console.WriteLine("Add complute");
			return;
		}
		public void print()
		{
			Node move = First;
			while (move!=null) {

                Console.WriteLine(move.Data);
                Console.WriteLine("___________");
				move = move.Next;
			}

		}
	}
	private static void Main(string[] args)
	{List student=new List();
		int opation;
		do
		{
		 
			do
		      {

		Console.WriteLine("1_Add student\n2_print\n3_exite");
		 opation=int.Parse(Console.ReadLine());
		} while (opation<1||opation>3);
			if (opation==3)
			{
                Console.WriteLine("thanks");
				break;
			}
			if (opation==1)
			{
				Student s =new Student();
				
				student.Add(s);
			}
			if (opation==2)
			{
				student.print();
			}

		} while (opation!=3);
	}
}