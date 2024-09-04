using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        List<Payment> GetAll();
        void Add(Payment payment);
        void Update(Payment payment);
        void Delete(Payment payment);
        Payment GetById(int paymentId);
    }
}
