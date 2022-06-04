import React, { useState, useEffect } from "react";

import { BillCard } from "../components";
import {Card } from 'reactstrap'
import { getAllBills } from '../Data/BilllData';


// const Content = styled.div`
//   display: flex;
//   flex-wrap: wrap;
//   justify-content: center;
//   text-align: center;
//   padding-top: 20px;
// `;

export default function ArchiveFolder() {
  const [bills, setBills] = useState([]);
  const [billReviewed] = useState(true);

  useEffect(() => {
    let isMounted = true;
    getAllBills().then((billsArray) => {
      if (isMounted) setBills(billsArray);
    });
  });

  return (
    <Card>
      {bills.map((bill) => (
        <BillCard key={bill.id} bill={bill} billReviewed={billReviewed} />
      ))}
    </Card>
  );
}