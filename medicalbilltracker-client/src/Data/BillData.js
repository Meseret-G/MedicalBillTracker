import axios from "axios";

const baseURL = "https://localhost:7033/api";


const createBill = (billObj) => 
 new Promise((resolve, reject) => {
   axios
    .post(`${baseURL}/Bill`, billObj).then(resolve).catch(reject);
 });

//  const createBill = (billObj) =>
//   new Promise((resolve, reject) => {
//     axios
//       .post(`${baseURL}/Bill`, billObj)
//       .then((response) => {
//         if (response.status > 300 || response.status < 200) {
//           throw new Error(response.status);
//         } else {
//           resolve();
//         }
//       })
//       .catch(reject);
//   });

const getAllBills = async () => {
  const bill = await axios.get(`${baseURL}/Bill`, {
  });
  const billData = bill.data;
  return billData;
};


 const getBillById = async (billId) => {
    const billArray = await axios.get(`${baseURL}/Bill/${billId}`);
    const billData = billArray.data;
    return billData;
  };

  const deleteBill = (billId) =>
  new Promise((resolve, reject) => {
    axios
      .delete(`${baseURL}/Bill/Delete/${billId}`)
      .then(() => getAllBills().then(resolve))
      .catch(reject);
  });

 export { createBill, getBillById, getAllBills, deleteBill };