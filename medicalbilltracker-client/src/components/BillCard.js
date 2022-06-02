import React from 'react';
import { useNavigate } from 'react-router-dom';
import { 
  CardTitle,
  CardBody,
  Button,
  CardSubtitle,
  CardImg,
  Card,
} from 'reactstrap';

export default function BillCard({ bill, handleDelete }) {    

        const navigate = useNavigate();
        
     
        return (
          <div className='home-container'>
            <Card className='bill-card'>
              <CardTitle className='bill-name'>{bill.title}</CardTitle>
              <CardImg
                alt='bill image'
                className='bill-image'
                src={bill.imageURL}
                onClick={() => navigate(`/BillDetail/${bill.id}`)}
              />
              <CardBody>
                <CardSubtitle className='bill-color'>{bill.provider}</CardSubtitle>
                <CardSubtitle className='bill-color'>{bill.imageURL}</CardSubtitle>
                <CardSubtitle className='bill-color'>{bill.outOfPocket}</CardSubtitle>
                      <Button
                        className='edit-bill'
                        onClick={() => navigate(`/Edit/${bill.id}`)}
                      >
                        Edit
                      </Button>
                    <Button
                      className='btn btn-danger'
                      type='button'
                      onClick={() => handleDelete(bill.id)}
                    >
                      Delete
                    </Button>
                    <Button
                      className='btn btn-danger'
                      type='button' >                 
                     Archive 
                    </Button>
              </CardBody>
            </Card>
          </div>
        );
      }
      