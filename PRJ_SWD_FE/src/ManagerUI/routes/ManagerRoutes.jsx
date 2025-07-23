// ManagerRoutes.jsx
import React from "react";
import { Route, Navigate } from "react-router-dom";
import Reservation from "../views/Reservation/Reservation";
import Blog from "../views/Blog/Blog"; 
import BlogDetail from '../views/Blog/BlogDetail';
import BlogCreate from '../views/Blog/BlogCreate';
import BlogUpdate from '../views/Blog/BlogUpdate';
import ReservationCreate from '../views/Reservation/ReservationCreate';
import ReservationDetail from "../views/Reservation/ReservationDetail";
import ReservationUpdate from "../views/Reservation/ReservationUpdate";
import Service from "../views/Service/Service";
import ServiceCreate from "../views/Service/ServiceCreate";
import ServiceEdit from "../views/Service/ServiceEdit";
import ServiceDetail from "../views/Service/ServiceDetail";
import OrderBill from "../views/OrderBill/OrderBill";
import OrderBillCreate from "../views/OrderBill/OrderBillCreate";
import OrderBillUpdate from "../views/OrderBill/OrderBillUpdate";
import OrderBillDetail from "../views/OrderBill/OrderBillDetail";
const routes = [
  <Route key="home" path="/" element={<Navigate to="/reservation" />} />,
  <Route key="reservation" path="/reservation" element={<Reservation />} />,
  <Route key="blog" path="/blog" element={<Blog />} />,
  <Route key="blog-detail" path="/blog/detail/:id" element={<BlogDetail />} />,
  <Route key="blog-create" path="/blog/create" element={<BlogCreate />} />,
  <Route key="blog-edit" path="/blog/edit/:id" element={<BlogUpdate />} />,
 <Route key="orderbill" path="/orderbill" element={<OrderBill />} />,
<Route key="orderbill-create" path="/orderbill/create" element={<OrderBillCreate />} />,
<Route key="orderbill-edit" path="/orderbill/edit/:id" element={<OrderBillUpdate />} />,
<Route key="orderbill-detail" path="/orderbill/detail/:id" element={<OrderBillDetail />} />,
  <Route key="reservation-create" path="/reservation/create" element={<ReservationCreate />} />,
  <Route key="reservation-detail" path="/reservation/detail/:id" element={<ReservationDetail />} />,
  <Route key="reservation-edit" path="/reservation/edit/:id" element={<ReservationUpdate />} />,
  <Route key="service" path="/service" element={<Service />} />,
  <Route key="service-create" path="/service/create" element={<ServiceCreate />} />,
  <Route key="service-edit" path="/service/edit/:id" element={<ServiceEdit />} />,
  <Route key="service-detail" path="/service/detail/:id" element={<ServiceDetail />} />,
];

export default routes;
