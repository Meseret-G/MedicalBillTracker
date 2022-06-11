/* eslint-disable no-undef */
import React from 'react';
import { useNavigate } from 'react-router-dom';
// import { 
//   CardTitle,
//   CardBody,
//   Button,
//   CardSubtitle,
//   CardImg,
//   Card,
//   CardHeader,
//   CardFooter
// Modal, ModalBody, ModalFooter
//  } from 'reactstrap';
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
            console.log("handle click for archive is hit")
            archiveBill(bill.id, bill)
            navigate("/Archive");
        }
        
      
        return (
          <div className="home-container"> 
       <div className="flip-card">

         <div className="flip-card-inner">
           <div className="flip-card-front">
         
           <h1 className="provider-name">{bill.title}</h1>
           <h1 className="provider-name">${bill.outOfPocket}</h1>

           {/* <h1 className="provider-name">{bill.date}</h1> */}
         
        </div>
        
      
         <div className="flip-card-back">
         <h1 className="provider-name">{bill.provider}</h1>
         <h1 className="provider-name">{bill.personalNote}</h1>
         <img
           alt="providerimage"
           src= {bill.imageURL}
            className="image-url"
            style={{width: "300px", height: "200px"}}
            onClick={() => navigate(`/BillDetail/${bill.id}`)}
         />
           <button
                        className='edit-bill'
                        onClick={() => navigate(`/Edit/${bill.id}`)}
                      >
                        Edit
                      </button>
                    <button
                      className='btn btn-danger'
                      type='button'
                     
                      onClick={() => handleDelete(bill.id)}
                 
                    >
                      Delete
                      
                    </button>

                  
            
                    {!billReviewed && ( 
                    <button
                      className='add-to-archive'
                      type='button'
                      onClick={() => handleClick()}                      
                      >                 
                     Archive 
                    </button>
                    )}

         </div>
         </div>
         </div>

            {/* <Card className='bill-card'>
              <CardHeader className = "card-header">Header</CardHeader>
              <CardBody>
              <CardTitle className='bill-name'>{bill.title}</CardTitle>
              <CardImg
                alt='bill image'
                className='bill-image'
                src={bill.imageURL}
                onClick={() => navigate(`/BillDetail/${bill.id}`)}
              />
              
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
              <CardFooter className="card-footer">Footer</CardFooter>
            </Card> */}
      </div>
      
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

    
      