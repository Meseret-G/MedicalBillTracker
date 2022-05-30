import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { BillForm, BillDetails } from '../components/index';
import Bill from '../views/Bill';


export default function AppRoutes() {
  return (
    <>
      <Routes>
        <Route path='/' element={<Bill />} />
        <Route path='/BillForm' element={<BillForm />} />
        <Route
          path='/BillDetail/:dbKey'
          element={<BillDetails  />}
        />
      </Routes>
    </>
  );
}
