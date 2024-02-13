using System.Diagnostics;

namespace DesignPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Factory Method Pattern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_FactoryMethod_Click(object sender, EventArgs e)
        {
            // ConcreteCreator1을 사용하여 ConcreteProduct1 생성
            Creator creator1 = new ConcreteCreator_1();
            IProduct product1 = creator1.FactoryMethod();
            Debug.WriteLine(product1.Operation());

            // ConcreteCreator2를 사용하여 ConcreteProduct2 생성
            Creator creator2 = new ConcreteCreator_2();
            IProduct product2 = creator2.FactoryMethod();
            Debug.WriteLine(product2.Operation());
        }



    }
}