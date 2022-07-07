using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    public class Users : IClassModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string OtherUserDetails { get; set; }
        public int AmountOfFine { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Users()
        {

        }
        public Users(string userName, string userAddress, string otherUserDetails, int amountOfFine, string email, string phoneNumber)
        {
            UserName = userName;
            UserAddress = userAddress;
            OtherUserDetails = otherUserDetails;
            AmountOfFine = amountOfFine;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"Id = {Id}\n" +
                $"Username = {UserName}\n" +
                $"Address = {UserAddress}\n" +
                $"Details = {OtherUserDetails}\n" +
                $"Fine Amount = {AmountOfFine}\n" +
                $"Email = {Email}\n" +
                $"Phone Number = {PhoneNumber}\n";
        }
    }
}
