using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering_OP_6 {
	class RowInTable {

		public string productName { get; set; }
		public string productCode { get; set; }

		public string measurmentUnitName { get; set; }
		public string measurmentUnitCode { get; set; }

		public string leaveTime_1 { get; set; }
		public string leaveTime_2 { get; set; }
		public string leaveTime_3 { get; set; }
		public string leaveTime_4 { get; set; }
		public string leaveTime_5 { get; set; }
		public string leaveTime_6 { get; set; }

		public string productReturned { get; set; }

		public string productReturnedWithoutLeaving { get; set; }

		public string discountPrice { get; set; }
		public string sellingPrice { get; set; }

		public string discountPriceSum { get; set; }
		public string sellingPriceSum { get; set; }

		public string note { get; set; }

		public RowInTable() {
			productName = "";
			productCode = "";
			measurmentUnitName = "";
			measurmentUnitCode = "";
			leaveTime_1 = "";
			leaveTime_2 = "";
			leaveTime_3 = "";
			leaveTime_4 = "";
			leaveTime_5 = "";
			leaveTime_6 = "";
			productReturned = "";
			productReturnedWithoutLeaving = "";
			discountPrice = "";
			sellingPrice = "";
			discountPriceSum = "";
			sellingPriceSum = "";
			note = "";
		}
	}
}
