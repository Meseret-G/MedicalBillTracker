import React from 'react'

import {
  Card,
  CardBody,
  
  CardImg,
  CardText,
  CardTitle,

} from "reactstrap";

// const CardStyle = styled(Card)`
//   border: 2px black solid;
//   background-color: white;
//   border-radius: 5px;
//   margin: 20px;
//   padding: 0px;
//   box-shadow: 8px 8px 4px;
// `;

export default function ArchiveCard({ archive }) {
  return (
   <Card>
       <CardBody>
           <CardImg
             style={{ width: "300px", height: "300px" }}
             src={archive.imageURL}
             alt={archive.title}
           />
           <CardTitle tag="h2">{archive.provider}</CardTitle>
           <CardText tag="h4">${archive.OutofPocket}</CardText>
       </CardBody>
   </Card>
  );
}
