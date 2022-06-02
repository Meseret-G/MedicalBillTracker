import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { BillForm  } from '../components/index';
import { getBillById } from '../Data/BilllData';

export default function EditBill() {
  let { dbKey } = useParams();
  const [editItem, setEditItem] = useState({});

  useEffect(() => {
    getBillById(dbKey).then(setEditItem);
  }, []);
  return (
    <>
      <h3 className="edit-view">
        Edit Bill
      </h3>
      <div className="form-container">
        <BillForm editItem={editItem} />
      </div>
    </>
  );
}