using BusinessRuleEngine.Common;
using BusinessRuleEngine.Interfaces;
using BusinessRuleEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.Services
{
    public class VideoPayment : ProcessOrderFactory<ProductInfo>
    {
        protected override PaymentResult ProcessPayment(ProductInfo model)
        {
            if (!string.IsNullOrEmpty(model.Description))
            {
                if (model.Description.ToLowerInvariant() == VideoTypes.VIDEO_TITLE_FOR_CHECK)
                {
                    return new PaymentResult
                    {
                        IsSuccess = true,
                        Message = "Added First Aid video to the packing slip."
                    };
                }
                else
                {
                    return new PaymentResult
                    {
                        IsSuccess = true,
                        Message = "Generated Packing slip"
                    };
                }
            }
            else
            {
                throw new InvalidOperationException("Video Descrption is missing");
            }
        }
    }
}
