using System;
using System.Windows.Forms;

namespace Blood_Bank.Helpers
{
    public static class FormNavigator
    {
        private static Form _currentForm;

        public static void NavigateTo(Form newForm, Form currentForm)
        {
            _currentForm = currentForm;
            newForm.FormClosed += (s, e) => _currentForm.Show();
            newForm.Show();
            _currentForm.Hide();
        }
    }
}
