import React, {useState, useEffect } from 'react';
import { Button } from 'reactstrap';
import {useNavigate} from 'react-router-dom';
import BillCard from '../components/BillCard';
import { getAllBills } from '../Data/BillData';

export default function Bill() {
    const navigate = useNavigate();
    const [bills, setBills] = useState([]);

    useEffect(() => {
      let isMounted = true;
      getAllBills().then((billArray) => {
        if (isMounted) setBills(billArray);
      });
      return () => {
        isMounted = false;
      };
    }, []);
  
    return (
      
        <div className='add-bill-btn-container page-section'>
       
          <div className='add-bill-btn'>
            <Button
              className='btn btn-success'
              onClick={() => navigate(`/BillForm`)}
            >
              Add New Bill
            </Button>
          
          </div>
        
        <div className='bill-view-page'> 
        <>
        {bills.map((bill) => (
         
         <BillCard

        key={bill.id}
        bill={bill}
         
       />
        ))}
         
        </>
      </div>
      </div>
     
      
    );
}

