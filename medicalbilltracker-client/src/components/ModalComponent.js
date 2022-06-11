// import React, { useState } from 'react';
// //import { useNavigate } from 'react-router-dom';
// import { ModalBody, ModalHeader, ModalFooter,Button } from 'reactstrap';
// import { Modal } from 'reactstrap';
// import { getAllBills, deleteBill } from '../Data/BilllData';
// import PropTypes from "prop-types";

// export default function ModalComponent({ bill , id }) {

//     const [setBills] = useState([]);
//     const [showModal, setShowModal] = useState(false);
//     const handleShowModal = () => {setShowModal(true); console.log(id)};
//     const handleCloseModal = () => setShowModal(false);

//     //const navigate = useNavigate();

//     const handleDelete = async (id) => {

//         await deleteBill(id);
//         //navigate('/');
//         getAllBills().then((billArray) => setBills(billArray));
//       };
    

//     return (
//         <>
//         <div className="modal">
//             <Button variant="primary" onClick={handleShowModal} id={id}> 
//                 Delete
//             </Button>
//         <Modal isOpen={showModal} > 
//         <ModalHeader>Modal Header</ModalHeader>
//         <ModalBody> Are you sure? </ModalBody>
//         <ModalFooter>           
//         <Button variant="primary" onClick={handleCloseModal}> Close</Button> 
//         <Button variant="secondary"onClick={() =>handleDelete(bill.id)}> Confirm Delete </Button>  

//         </ModalFooter>           
//         </Modal>
//         </div>  
   
        
//         </>
//     );
// }

// ModalComponent.propTypes = {
//    id: PropTypes.number,
//     bills:PropTypes.array
   
//   };


