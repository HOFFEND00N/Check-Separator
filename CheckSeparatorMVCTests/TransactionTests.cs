using CheckSeparatorMVC.Models;
using System.Collections.Generic;
using Xunit;

namespace CheckSeparatorMVCTests
{
    public class TransactionTests
    {
        [Fact]
        public void MakeTransactionList_ReturnsNull()
        {
            List<Product> products = new List<Product>();

            var transactions = Transaction.MakeTransactionList(products);

            Assert.Empty(transactions);
        }

        [Fact]
        public void MakeTransactionList_ReturnsOneTransaction()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(1, "water", 40, 1));
            var user = new User();
            user.UserName = "test";
            products[0].ProductUsers = new List<ProductUser>();
            products[0].ProductUsers.Add(new ProductUser(user, products[0]));
            products[0].ProductUsers[0].User = user;
            products[0].Check = new Check(user);
            TransactionEqualityComparer transactionEqualityComparer = new TransactionEqualityComparer();

            var expectedTransaction = new List<Transaction>();
            expectedTransaction.Add(new Transaction("test", "test", 40));

            var actualTransactions = Transaction.MakeTransactionList(products);

            Assert.Equal(expectedTransaction, actualTransactions, transactionEqualityComparer);
        }


        [Fact]
        public void MakeTransactionList_ReturnsTwoTransactionsForOneProduct()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(1, "water", 40, 1));
            var user1 = new User();
            var user2 = new User();
            user1.UserName = "user1";
            user2.UserName = "user2";
            products[0].ProductUsers = new List<ProductUser>();
            products[0].ProductUsers.Add(new ProductUser(user1, products[0]));
            products[0].ProductUsers.Add(new ProductUser(user2, products[0]));
            products[0].ProductUsers[0].User = user1;
            products[0].ProductUsers[1].User = user2;
            products[0].Check = new Check(user1);
            TransactionEqualityComparer transactionEqualityComparer = new TransactionEqualityComparer();

            var expectedTransaction = new List<Transaction>();
            expectedTransaction.Add(new Transaction("user1", "user1", 20));
            expectedTransaction.Add(new Transaction("user2", "user1", 20));

            var actualTransactions = Transaction.MakeTransactionList(products);

            Assert.Equal(expectedTransaction, actualTransactions, transactionEqualityComparer);
        }

        [Fact]
        public void MakeTransactionList_ReturnsTwoTransactionsForTwoProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(1, "water", 40, 1));
            products.Add(new Product(2, "salt", 100, 2));
            var user1 = new User();
            var user2 = new User();
            user1.UserName = "user1";
            user2.UserName = "user2";
            products[0].ProductUsers = new List<ProductUser>();
            products[0].ProductUsers.Add(new ProductUser(user1, products[0]));
            products[1].ProductUsers = new List<ProductUser>();
            products[1].ProductUsers.Add(new ProductUser(user2, products[1]));
            products[0].ProductUsers[0].User = user1;
            products[1].ProductUsers[0].User = user2;
            products[0].Check = new Check(user1);
            products[1].Check = products[0].Check;
            TransactionEqualityComparer transactionEqualityComparer = new TransactionEqualityComparer();

            var expectedTransaction = new List<Transaction>();
            expectedTransaction.Add(new Transaction("user1", "user1", 40));
            expectedTransaction.Add(new Transaction("user2", "user1", 200));

            var actualTransactions = Transaction.MakeTransactionList(products);

            Assert.Equal(expectedTransaction, actualTransactions, transactionEqualityComparer);
        }
    }

    public class TransactionEqualityComparer : IEqualityComparer<Transaction>
    {
        public bool Equals(Transaction x, Transaction y)
        {
            if (x.Recipient == y.Recipient && x.Sender == y.Sender && x.TransactionSize == y.TransactionSize)
                return true;
            return false;
        }

        public int GetHashCode(Transaction obj)
        {
            var tCode = obj.Sender + obj.Recipient + obj.TransactionSize;
            return tCode.GetHashCode();
        }
    }
}
