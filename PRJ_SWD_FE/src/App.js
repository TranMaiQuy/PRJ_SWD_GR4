import React from "react";
import { BrowserRouter, Routes } from "react-router-dom";
import ManagerRoutes from "./ManagerUI/routes/ManagerRoutes";
import StaffRoutes from "./StaffUI/routes/StaffRoutes";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        {ManagerRoutes}
        {StaffRoutes}
      </Routes>
    </BrowserRouter>
  );
}

export default App;
