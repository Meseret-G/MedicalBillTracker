import React, {useState, useEffect } from 'react';
import { Button } from 'reactstrap';
import {useNavigate} from 'react-router-dom';

import { deleteBill, getAllBills } from '../Data/BilllData';
import { BillCard } from '../components';
import SearchBill from '../components/SearchBill';


export default function Bill() {
    const navigate = useNavigate();
    const [bills, setBills] = useState([]);
    const [filteredData, setFilteredData] = useState([]);

    useEffect(() => {
      let isMounted = true;
      getAllBills().then((billArray) => {
        if (isMounted) setBills(billArray);
      });
      return () => {
        isMounted = false;
      };
    }, []);

    const handleDelete = async (billId) => {
      await deleteBill(billId);
      getAllBills().then((billArray) => setBills(billArray));
    };
  
    return (
      <>
      
        <div className='add-bill-btn-container page-section'>
       
          <div className='add-bill-btn'>
            <Button
              className='btn btn-success'
              onClick={() => navigate(`/BillForm`)}
            >
              Add New Bill
            </Button>
          
          </div>
          <div className='search-filter'>
          <SearchBill
            placeholder='Search by Name Or Provider'
            func={setFilteredData}
            data={bills}
          />
        </div>
        </div>

        <div className='bill-view-page page-section'> 
        <>
        {filteredData.length
            ? filteredData.map((bill) => (
                <BillCard
                  key={bill.id}
                  bill={bill}
                  bills={bills}
                  setBills={setBills}
                />
              )) :
        bills.map((bill) => (
         
         <BillCard
        key={bill.id}
        bill={bill}
       handleDelete={handleDelete}      
       />
        ))}        
        </>
      </div>
      
      </>
    );
}