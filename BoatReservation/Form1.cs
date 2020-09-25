using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoatReservation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool ValidInputs(out int noOfAdults, out int noOfChildren)
        {
            noOfAdults = 0;
            noOfChildren = 0;

            //Trying to parse the noOfAdults text box as a Integer value.
            if (!int.TryParse(this.txtAdults.Text, out noOfAdults))
            {
                //If the parsing fails, prompting user with error message
                MessageBox.Show("Please enter a valid integer value for number of adults.", "Reservation Failed");
                return false;
            }

            //Trying to parse the noOfChildren text box as a Integer value.
            if (!int.TryParse(this.txtChildren.Text, out noOfChildren))
            {
                //If the parsing fails, prompting user with error message
                MessageBox.Show("Please enter a valid integer value for number of children.", "Reservation Failed");
                return false;
            }

            //Validating the boat type for a valid selection
            if (String.IsNullOrEmpty(this.cmbxBoatType.SelectedItem.ToString()))
            {
                //If the parsing fails, prompting user with error message
                MessageBox.Show("Please select a valid boat type.", "Reservation Failed");
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int noOfAdults = 0, noOfChildren = 0;
            //Checking if all the inputs are valid
            if (!ValidInputs(out noOfAdults, out noOfChildren))
            {
                //If any of them is invalid, then updating the status as invalid data
                this.lblReservationStatus.Text = "Invalid data";
            }
            else
            {
                //If all the inputs are valid, then updating the status as valid data
                this.lblReservationStatus.Text = "Valid data";
                
                //Disabling the inputs and the check reservation button
                this.txtAdults.Enabled = false;
                this.txtChildren.Enabled = false;
                this.cmbxBoatType.Enabled = false;
                this.btnCheckReservation.Enabled = false;

                //Enabling the reserve button
                this.btnReserve.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Clearing all the input fields
            this.lblReservationStatus.Text = "";
            this.txtAdults.Text = "";
            this.txtChildren.Text = "";
            this.cmbxBoatType.Text = "";

            //Enabling the input fields adn the check reservation button
            this.txtAdults.Enabled = true;
            this.txtChildren.Enabled = true;
            this.cmbxBoatType.Enabled = true;
            this.btnCheckReservation.Enabled = true;

            //Disabling the reserve button
            this.btnReserve.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Closing the Form
            this.Close();
        }

        private void CheckKayak(int noOfAdults, int noOfChildren)
        {
            //Checking if the condition for Kayak boat is satisfied
            if(noOfAdults == 1 && noOfChildren == 0)
            {
                MessageBox.Show("You have successfully reserved a Kayak boat.", "Reservation Success");
                return;
            }
            
            //If the condition failed, prompting user with message box
            MessageBox.Show("A Kayak can be rented by only one Adult.", "Reservation Failed");
        }

        private void CheckCanoe(int noOfAdults, int noOfChildren)
        {
            //Checking if the condition for Canoe boat is satisfied
            if ((noOfAdults + noOfChildren) == 2)
            {
                MessageBox.Show("You have successfully reserved a Canoe boat.", "Reservation Success");
                return;
            }

            //If the condition failed, prompting user with message box
            MessageBox.Show("A Canoe can be rented by either two Adults or one adult with one child.", "Reservation Failed");
        }
        private void CheckPaddleboard(int noOfAdults, int noOfChildren)
        {
            //Checking if the condition for Paddleboard boat is satisfied
            if (noOfAdults == 1 && noOfChildren <= 1)
            {
                MessageBox.Show("You have successfully reserved a Paddleboard boat.", "Reservation Success");
                return;
            }

            //If the condition failed, prompting user with message box
            MessageBox.Show("A Paddleboard can be rented by either one adult or one adult with one child.", "Reservation Failed");
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            int noOfAdults = 0, noOfChildren = 0;

            if (ValidInputs(out noOfAdults, out noOfChildren))
            {
                String boatType = this.cmbxBoatType.SelectedItem.ToString();
                //Based on the boat type, invoking the corresponding method to check the boat condition.
                if (boatType.Equals("Kayak"))
                {
                    this.CheckKayak(noOfAdults, noOfChildren);
                }
                else if (boatType.Equals("Canoe"))
                {
                    this.CheckCanoe(noOfAdults, noOfChildren);
                }
                else if (boatType.Equals("PaddleBoard"))
                {
                    this.CheckPaddleboard(noOfAdults, noOfChildren);
                }
            }
        }
    }
}
