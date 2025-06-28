import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Reservation from "../views/Reservation/Reservation";
import Blog from "../views/Blog/Blog"; 
import BlogDetail from '../views/Blog/BlogDetail';
import BlogCreate from '../views/Blog/BlogCreate';

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/reservation" />} />
      <Route path="/reservation" element={<Reservation />} />
      <Route path="/blog" element={<Blog />} />
      <Route path="/blog/detail/:id" element={<BlogDetail />} />
      <Route path="/blog/create" element={<BlogCreate/>} />
    </Routes>
  );
};

export default AppRoutes;