import React from 'react';
import { Route, Routes } from 'react-router-dom';
import BillForm from '../components/BillForm';
import Bill from '../views/Bill';


export default function AppRoutes() {
  return (
    <>
      <Routes>
        <Route path='/' element={<Bill />} />
        <Route path='/BillForm' element={<BillForm />} />
      </Routes>
    </>
  );
}
