import { Routes, Route } from "react-router-dom";
import Permissions from "../../views/Permission/Permissions.jsx";
import Permission from "../../views/Permission/Permission.jsx";

const NavigationContainer = () => {

  return (
    <Routes>
      <Route index element={<Permissions />} />
      <Route path="edit/:id" element={<Permission action='edit' />} />
      <Route path="add" element={<Permission action='add' />} />
    </Routes>
  );
};

export default NavigationContainer;