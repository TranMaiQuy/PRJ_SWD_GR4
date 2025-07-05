import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Reservation from "../views/Reservation/Reservation";
import Blog from "../views/Blog/Blog"; 
import BlogDetail from '../views/Blog/BlogDetail';
import BlogCreate from '../views/Blog/BlogCreate';
import BlogUpdate from '../views/Blog/BlogUpdate';
import ReservationCreate from '../views/Reservation/ReservationCreate';
import ReservationDetail from "../views/Reservation/ReservationDetail";
import ReservationUpdate from "../views/Reservation/ReservationUpdate";

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/reservation" />} />
      <Route path="/reservation" element={<Reservation />} />
      <Route path="/blog" element={<Blog />} />
      <Route path="/blog/detail/:id" element={<BlogDetail />} />
      <Route path="/blog/create" element={<BlogCreate/>} />
      <Route path="/blog/edit/:id" element={<BlogUpdate/>} />
      <Route path="/reservation/create" element={<ReservationCreate />} />
      <Route path="/reservation/detail/:id" element={<ReservationDetail />} />
      <Route path="/reservation/edit/:id" element={<ReservationUpdate />} /> 
    </Routes>
  );
};

export default AppRoutes;