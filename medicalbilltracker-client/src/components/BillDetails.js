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
      <h6 className="detail-header" style={{fontWeight:"bolder", fontSize: "35px", color:"#F55A00", paddingBottom:"8px"}}> Bill Details</h6>
      <table className="bill-table">
        <thead>
          <tr className="bill-table-row">

            <th className="bill-table-cell th" >Title</th>
            <th className="bill-table-cell th">Provider</th>
            <th className="bill-table-cell th">Comment</th>
            <th className="bill-table-cell th">Out of Pocket</th>  
          </tr>
        </thead>
        <tbody>
          <tr className="bill-table-row">
            <td className="bill-table-cell">{billDetail.title}</td>
            <td className="bill-table-cell">{billDetail.provider}</td>
            <td className="bill-table-cell">{billDetail.personalNote}</td>
            <td className="bill-table-cell">${billDetail.outOfPocket}</td>
            
          </tr>
        </tbody>
      </table>
      <div className="detail-btn">
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
              </div>
      {/* <Card className='bill-details-card'>
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
      </Card>     */}
    </div>
  );
};