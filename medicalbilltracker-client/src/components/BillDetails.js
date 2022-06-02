import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import { getBillById, deleteBill } from '../Data/BilllData';
import { useNavigate } from "react-router-dom";
import {
  Card,
  CardTitle,
  CardBody,
  CardSubtitle,
  CardImg,
  Button,
} from 'reactstrap';

export default function BillDetails() {
  const [billDetail, setBillDetail] = useState([]);
  const { dbKey } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    getBillById(dbKey).then(setBillDetail);
    return () => {
    };
  }, []); 

  const handleDelete = (billId) => {
    deleteBill(billId) 
    navigate('/')
    };

  return (
    <div className='bill-details-container'>
      <Card className='bill-details-card'>
        <CardImg
          alt="bill image"
          className="bill-image"
          src={billDetail.imageURL}
        />
        <CardTitle className='bill-details-name'>{billDetail.title}</CardTitle>
        <CardBody>
          <CardSubtitle className='bill-details-provider'>{billDetail.provider}</CardSubtitle>
          <CardSubtitle className='bill-color'>{billDetail.imageURL}</CardSubtitle>
          <CardSubtitle className='bill-details-specs'>{billDetail.outOfPocket}</CardSubtitle>
          
        </CardBody>              
                <Button
                  className='edit-bill-detail'
                  onClick={() => navigate(`/Edit/${billDetail.id}`)}
                >
                  Edit
                </Button>        
                <Button
                  className='delete-bill-detail'
                  onClick={() => handleDelete(billDetail.id)}
                >
                Delete
              </Button>          
      </Card>    
    </div>
  );
};