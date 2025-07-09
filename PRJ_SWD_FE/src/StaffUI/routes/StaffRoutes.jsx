import React from "react";
import { Route } from "react-router-dom";
import Medicine from "../views/Medicine/Medicine";

const staffRoutes = [
  <Route key="medicine" path="/medicine" element={<Medicine />} />
];

export default staffRoutes;
