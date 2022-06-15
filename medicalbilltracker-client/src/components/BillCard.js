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


export default function BillCard({ bill, handleDelete }) {    


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

           <h1 className="provider-name">{bill.provider}</h1>
           <h1 className="provider-name">${bill.outOfPocket}</h1>
     
      
       
      
          
         
         
        </div>
        
      
         <div className="flip-card-back">
         <h1 className="provider-name">{bill.title}</h1>
            
       <img
         alt="providerimage"
         src= {bill.imageURL}
          className="image-url"
          style={{width: "300px", height: "200px"}}
          onClick={() => navigate(`/BillDetail/${bill.id}`)}
       />
        
        <h1 className="provider-name">{bill.personalNote}</h1>

         <div className="button-container">
         <button
                      className='edit-bill'
                      onClick={() => navigate(`/Edit/${bill.id}`)}
                    >
                      Edit
                    </button>
                  <button
                    className='delete-bill'
                    type='button'
                   
                    onClick={() => handleDelete(bill.id)}
               
                  >
                    Delete                      
                  </button>        
                  {!bill.isArchived ? ( 
                  <button
                    className='archive-btn'
                    type='button'
                    onClick={() => handleClick()}                      
                    >                 
                   Archive 
                  </button>
                  ) : ('')}
            </div>
         

        
        
       
         </div>
         </div>
         </div>

            
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

    
      