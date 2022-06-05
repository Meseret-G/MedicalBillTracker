/* eslint-disable no-undef */
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
import { archiveBill } from '../Data/BilllData';
import PropTypes from "prop-types";
//import styled from 'styled-components';

// const ButtonStyle = styled(Button)`
//   border-radius: 5px;
//   background-color: #F9F6EE;
//   width: 150px;
//   height: 40px;
//   margin-bottom: 10px;
//   border: 2px solid black;
//   box-shadow: 1px 1px 1px;
// `;

export default function BillCard({ bill, handleDelete, billReviewed }) {    


        const navigate = useNavigate();

        const handleClick = (e)=> {
            archiveBill(bill.id)
            navigate("/Archive");
        }
        
     
        return (
       
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
                <CardSubtitle className='bill-color'>${bill.outOfPocket}</CardSubtitle>
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
                    {!billReviewed && ( 
                    <Button
                      className='add-to-archive'
                      type='button'
                      onClick={handleClick}                      
                      >                 
                     Archive 
                    </Button>
                    )}
              </CardBody>
            </Card>
      
        );
      }

      BillCard.propTypes = {
        billCard: PropTypes.shape({
         id: PropTypes.number,
          title: PropTypes.string,
          imageURL: PropTypes.string,
          provider: PropTypes.string,
          outOfPocket: PropTypes.number
          
        })
       
      };

    
      