using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constans.Messages
{
    public static class PaymentMessages
    {
        public static string PaymentsListed = "Ödemeler başarıyla listelendi.";
        public static string PaymentNotFound = "Ödeme bulunamadı.";
        public static string PaymentAdded = "Ödeme başarıyla eklendi.";
        public static string PaymentUpdated = "Ödeme başarıyla güncellendi.";
        public static string PaymentDeleted = "Ödeme başarıyla silindi.";
        public static string InvalidPaymentAmount = "Ödeme miktarı sıfırdan büyük olmalıdır.";
        public static string NoPaymentsFound = "Hiç ödeme bulunamadı.";

    }
}
