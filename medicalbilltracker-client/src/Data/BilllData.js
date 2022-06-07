import axios from "axios";

const baseURL = "https://localhost:7033/api";


 const createBill = (billObj) =>
  new Promise((resolve, reject) => {
    axios
      .post(`${baseURL}/Bill`, billObj)
      .then((response) => {
        if (response.status > 400 || response.status < 200) {
          throw new Error(response.status);
        } else {
          resolve();
        }
      })
      .catch(reject);
         });

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

  
  const updateBill = (id, billObj) =>
  new Promise((resolve, reject) => {
    axios
      .put(`${baseURL}/Bill/Edit/${id}`, billObj)
      .then(() => getAllBills().then(resolve))
      .catch(reject);
  });

const archiveBill = ( billId, billObj) =>
new Promise((resolve, reject) => {
  axios.put(`${baseURL}/Bill/Archive/${billId}`, billObj)
  .then(() => getAllBills().then(resolve))
  .catch(reject);
});

const getArchiveBills = () =>
  new Promise((resolve, reject) => {
    axios
      .get(`${baseURL}/Bill/Archive`)
      .then((response) => resolve(Object.values(response.data)))
      .catch(reject);
  });

  
  
  const deleteArchiveBill = (billId) =>
  new Promise((resolve, reject) => {
    axios
      .delete(`${baseURL}/Bill/Archive/Delete/${billId}`)
      .then(() => getArchiveBills().then(resolve))
      .catch(reject);
  });


 export { createBill, getBillById, getAllBills, deleteBill, updateBill, archiveBill, getArchiveBills, deleteArchiveBill };