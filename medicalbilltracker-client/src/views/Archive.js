import React, { useState, useEffect } from "react";
import { CardBody, CardTitle } from "reactstrap";
import { BillCard } from "../components";

import { getArchiveBills, deleteArchiveBill } from "../Data/BilllData";

export default function Archive() {
  const [bills, setBills] = useState([]);
  const [archiveTotal, setArchiveTotal] = useState();

  const getOutOfPocketTotal = (bills) => {
    let outofPocketTotal = 0;
    bills.forEach((bill) => {
        outofPocketTotal += bill.outOfPocket;
    });
    setArchiveTotal(outofPocketTotal.toFixed(2));
  };

  useEffect(() => {
    let isMounted = true;
getArchiveBills().then((billArray) => {
      if (isMounted) setBills(billArray);
    });
    return () => {
      isMounted = false;
    };
  }, [bills]);

  useEffect(() => {
    getOutOfPocketTotal(bills);
  }, [bills]);


  // const handleDeleteArchive = async (billId) => {
  //   await deleteArchiveBill(billId);
  //   getArchiveBills().then((billArray) => setBills(billArray));
  // };

  return (
    <CardBody>
      {bills.length === 0 ? (
        <CardTitle>
          <h2>No archived Bills!</h2>
        </CardTitle>
      ) : (
        <CardBody>
          <CardTitle>
            <h3>Out Of Pocket Total: ${archiveTotal}</h3>
          </CardTitle>
          <CardBody>
          {bills.map((bill) => (
            <BillCard key={bill.Id} 
            bill={bill} 
         
             />
          ))}
          </CardBody>
        </CardBody>
      )}
    </CardBody>
  );
}