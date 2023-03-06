using static System.Net.Mime.MediaTypeNames;

namespace Gerador_de_cpf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(Generator()));
        }

        public static int Generator()
        {
            int A;
            int B;
            int CPF;
            string DispatchRegion = "";
            string DefinedDigits = "";
            Random random = new Random(); A = random.Next(10000000, 99999999);//Os primeiros 9 numeros sao aleatorios / The first 8 numbers are random
            Random Region = new Random(); B = Region.Next(0, 9);//O numero da regiao de expedicao varia de 1 a 10, com 0 sendo usado ao invez do 10 / The number of the dispatching region, goes from 1 to 10, with 0 being used for 10
            DefinedDigits = A.ToString();
            DispatchRegion = B.ToString();


            string temp = DefinedDigits + DispatchRegion;
            int[] numbers = new int[temp.Length]; //Cria um array de inteiros / Create array of ints
            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Convert.ToInt32(temp[i]);
            }


            for (int i = 10; i > 1; i--) //Os loops que seguem multiplicam o primeiro digito por 10, o segundo por 9 etc / The following loops multiply the 1st digit by 10, 2nd by 9 etc
            {
                for(int j = 0; j < 9; j++)
                {
                    numbers[j] *= i;
                }
            }


            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            sum = sum % 11; //apos somar todos os digitos do array numbers, divide-se o resultado por 11 para encontrar o resto / After adding all digits of the numbers array, the result is divided by 11 in order to find the remain


            int FirstVerifier; //esta parte e trivial e nao precisa ser explicada / this part is trivial and does not need explaining
            if(sum == 0 || sum == 1) { FirstVerifier = 0;}
            else { FirstVerifier = 11 - sum; }
            Array.Resize(ref numbers, numbers.Length + 1);//adicionar FirstVerifier ao array / adding the firstverifier to the array
            numbers[numbers.Length - 1] = FirstVerifier;


            for (int i = 10; i > 1; i--) //Os loops que seguem multiplicam o segundo digito por 10, o terceiro por 9 etc / The following loops multiply the 1st digit by 10, 2nd by 9 etc
            {
                for (int j = 1; j < 10; j++)
                {
                    numbers[j] *= i;
                }
            }


            sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            sum = sum % 11;


            int SecondVerifier;
            if (sum == 0 || sum == 1) { SecondVerifier = 0; }
            else { SecondVerifier = 11 - sum; }
            Array.Resize(ref numbers, numbers.Length + 1);//adicionar FirstVerifier ao array / adding the firstverifier to the array
            numbers[numbers.Length - 1] = SecondVerifier;


            CPF = int.Parse(string.Concat(numbers));
            return CPF;
            
        }
    }
}