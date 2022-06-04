import React, { useState, useEffect } from "react";
import { CardBody, CardTitle } from "reactstrap";
import { BillCard } from "../components";
import getArchive from "../Data/ArchiveData";


// const Content = styled.div`
//   display: flex;
//   flex-wrap: wrap;
//   justify-content: center;
//   text-align: center;
//   padding-top: 20px;
// `;

// const Total = styled.div`
//   display: flex;
//   width: 200px;
//   height: 65px;
//   border: 5px solid black;
//   border-radius: 10px;
//   justify-content: center;
//   align-content: center;
//   background-color: #F9F6EE;
// `;

// const Container = styled.div`
//   display: flex;
//   flex-direction: column;
//   align-items: center;
// `;

// const EmptyCartTextContainer = styled.div`
//   display: flex;
//   justify-content: center;
//   align-items: center;
//   width: 250px;
//   height: 100px;
//   border-radius: 10px;
//   border: black 5px solid;
//   background-color: #F9F6EE;
// `;

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
getArchive().then((billArray) => {
      if (isMounted) setBills(billArray);
    });
    return () => {
      isMounted = false;
    };
  }, [bills]);

  useEffect(() => {
    getOutOfPocketTotal(bills);
  }, [bills]);

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
            <BillCard key={bill.Id} bill={bill} />
          ))}
          </CardBody>
        </CardBody>
      )}
    </CardBody>
  );
}