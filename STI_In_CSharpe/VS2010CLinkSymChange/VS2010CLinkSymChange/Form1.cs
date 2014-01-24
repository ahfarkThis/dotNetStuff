//CODE DISCLAIMER
//Solely as an accommodation to Subscriber, Sterling has agreed to provide sample source code
//("Code") to demonstrate how Subscriber might be able to develop its own software code to
//facilitate Subscriber's interaction with the Sterling front-end modules via Sterling's Application
//Programming Interface (API).  Sterling is providing the Code "as is", and Sterling has no obligation to
//provide any updates, revisions, modifications or enhancements to the Code.  Sterling is not writing
//or assisting in writing Subscriber's code, and consequently Sterling has no responsibility or liability
//for Subscriber's use or modification of the Code.  STERLING EXPRESSLY DISCLAIMS ALL
//REPRESENTATIONS AND WARRANTIES, EXPRESS OR IMPLIED, WITH RESPECT
//TO THE CODE, INCLUDING THE WARRANTIES OF MERCHANTABILITY AND OF
//FITNESS FOR A PARTICULAR PURPOSE. UNDER NO CIRCUMSTANCES
//INCLUDING NEGLIGENCE SHALL STERLING BE LIABLE FOR ANY DAMAGES,
//INCIDENTAL, SPECIAL, CONSEQUENTIAL OR OTHERWISE (INCLUDING WITHOUT
//LIMITATION DAMAGES FOR LOSS OF PROFITS, BUSINESS INTERRUPTION, LOSS
//OF INFORMATION OR OTHER PECUNIARY LOSS) THAT MAY RESULT FROM THE
//USE OF OR INABILITY TO USE THE CODE, EVEN IF STERLING HAS BEEN ADVISED
//OF THE POSSIBILITY OF SUCH DAMAGES.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SterlingLib.STIApp stiapp = new SterlingLib.STIApp();

        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            stiapp.SwitchLinkGroupSymbol(1, "IBM 120727C215000", "O");
 
          
        }
    }
}
