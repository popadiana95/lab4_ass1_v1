using Ass2_1.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass2_1
{
    public partial class FormUser : Form
    {
        public int idUser;
        public FormUser(int idUser)
        {
            this.idUser = idUser;
            InitializeComponent();
        }

       
        private void dataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                Order order = dataGridViewOrders.SelectedRows[0].DataBoundItem as Order;
                if (order != null)
                {
                    textBoxId.Text = order.idOrder.ToString();
                    textBoxCustomer.Text = order.customer;
                    textBoxAddress.Text = order.address;
                    textBoxDate.Text = order.deliveryDate.ToString();
                    textBoxStatus.Text = order.status;
                    textBoxTotal.Text = order.total.ToString();

                }
            }
        }
        private void dataGridViewProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
               Product product = dataGridViewProducts.SelectedRows[0].DataBoundItem as Product;
                if (product != null)
                {

                    textBoxProductID.Text = product.idProduct.ToString();
                    textBoxTitle.Text = product.title;
                    textBoxDescription.Text = product.description;
                    textBoxColor.Text = product.color;
                    textBoxSize.Text = product.size;
                    textBoxPrice.Text = product.price.ToString();
                    textBoxStock.Text = product.stock.ToString();
                   
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OrderDBManager odbm = new OrderDBManager();

                dataGridViewOrders.DataSource = odbm.RetrieveOrders(idUser);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int RetriveQuantity()
        {
            int q = Convert.ToInt32(textBoxQuantity.Text);
            return q;
        }
        private Order RetrieveOrderInformation()
        {
            Order order = new Order();
            order.idOrder = Convert.ToInt32(textBoxId.Text);
            order.customer = textBoxCustomer.Text;
            order.address = textBoxAddress.Text;
            order.deliveryDate = textBoxDate.Value;
            order.status = textBoxStatus.Text;
            order.total = (float)Convert.ToDouble(textBoxTotal.Text);
            return order;
        }
        private Product RetriveProductInformation()
        {
            Product product = new Product();
            product.idProduct = Convert.ToInt32(textBoxProductID.Text);
            product.title = textBoxTitle.Text;
            product.description = textBoxDescription.Text;
            product.color = textBoxColor.Text;
            product.size = textBoxSize.Text;
            product.price = (float)Convert.ToDouble(textBoxPrice.Text);
            product.stock = Convert.ToInt32(textBoxStock.Text);
            return product;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Order order = RetrieveOrderInformation();

                OrderDBManager odbm = new OrderDBManager();
                odbm.UpdateOrder(order,idUser);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                Order order = RetrieveOrderInformation();

                OrderDBManager odbm = new OrderDBManager();
                odbm.DeleteOrder(order, idUser);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }


        private void buttonViewProducts_Click(object sender, EventArgs e)
        {
            try
            {
                ProductDBManager pdbm = new ProductDBManager();

                dataGridViewProducts.DataSource = pdbm.RetrieveProducts(idUser);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEditProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = RetriveProductInformation();
                Console.Write(product.idProduct);
                ProductDBManager pdbm = new ProductDBManager();
                pdbm.UpdateProduct(product, idUser);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = RetriveProductInformation();

                ProductDBManager pdbm = new ProductDBManager();
                pdbm.AddProduct(product, idUser);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = RetriveProductInformation();

                ProductDBManager pdbm = new ProductDBManager();
                pdbm.DeleteProduct(product, idUser);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Order order = RetrieveOrderInformation();
            OrderDBManager odbm = new OrderDBManager();
            dataGridViewOrderDetails.DataSource = odbm.getOrderDetails(order, idUser);
        }

        private void buttonAddProductToOrder_Click(object sender, EventArgs e)
        {
            Order order = RetrieveOrderInformation();
            Product product = RetriveProductInformation();
            int q = RetriveQuantity();
            Orders o = new Orders();
            string message = o.addProduct(order, product, q, idUser);
            MessageBox.Show(message);
        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            Order order = RetrieveOrderInformation();          
            OrderDBManager odbm = new OrderDBManager();
            odbm.AddOrder(order, idUser);
        }
    }
    }

