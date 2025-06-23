import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Reservation from "../views/Reservation/Reservation"; // ✅ Quan trọng

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/reservation" />} />
      <Route path="/reservation" element={<Reservation />} />
    </Routes>
  );
};

export default AppRoutes;