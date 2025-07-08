import React, { useEffect, useState } from "react";
import { useParams, useNavigate } from "react-router-dom";

function ReservationUpdate() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    reservationDate: "",
    note: "",
    status: 0,
    staffId: 0,
    personId: 0,
    customerName: "",
    selectedServiceIds: [],
  });

  const [allServices, setAllServices] = useState([]);
  const [allStaffs, setAllStaffs] = useState([]);
  const [loading, setLoading] = useState(true);

useEffect(() => {
  const fetchAllData = async () => {
    try {
      const [reservationRes, servicesRes, staffsRes] = await Promise.all([
        fetch(`https://localhost:7012/api/reservation/detail/${id}`),
        fetch(`https://localhost:7012/api/service/list`),
        fetch(`https://localhost:7012/api/staff/list`)
      ]);

      if (!reservationRes.ok || !servicesRes.ok || !staffsRes.ok)
        throw new Error("Failed to load data");

      const reservationData = await reservationRes.json();
      const servicesData = await servicesRes.json();
      const staffsData = await staffsRes.json();

     

      setFormData({
        reservationDate: reservationData.reservationDate,
        note: reservationData.note,
        status: reservationData.status,
        staffId: reservationData.staffId, // fix chỗ này
        personId: reservationData.customerId,
        customerName: reservationData.customerName,
        selectedServiceIds: reservationData.services.map(s => s.serviceId),
      });

      setAllServices(servicesData);
      setAllStaffs(staffsData);
      setLoading(false);
    } catch (err) {
      console.error("Load error:", err);
      setLoading(false);
    }
  };

  fetchAllData();
}, [id]);


  const handleChange = (e) => {
    const { name, value, checked, type } = e.target;

    if (name === "status") {
      setFormData(prev => ({
        ...prev,
        status: checked ? 1 : 0,
      }));
    } else {
      setFormData(prev => ({
        ...prev,
        [name]: type === "number" ? Number(value) : value,
      }));
    }
  };

  const handleServiceToggle = (serviceId) => {
    setFormData(prev => {
      const exists = prev.selectedServiceIds.includes(serviceId);
      return {
        ...prev,
        selectedServiceIds: exists
          ? prev.selectedServiceIds.filter(id => id !== serviceId)
          : [...prev.selectedServiceIds, serviceId]
      };
    });
  };
const getDefaultStaffName = () => {
  console.log("🔍 Current staffId from formData:", formData.staffId);
  console.log("🗂 All Staffs:", allStaffs);

  const staff = allStaffs.find(s => s.personId === formData.staffId);

  console.log("✅ Matched Staff:", staff);

  return staff ? staff.personName : "Select Staff";
};
 const handleSubmit = async (e) => {
  e.preventDefault();

  // ✅ Validate ngày không được trống
  if (!formData.reservationDate) {
    alert("Vui lòng chọn ngày đặt.");
    return;
  }

  // ✅ Validate ngày phải sau hiện tại
  const selectedDate = new Date(formData.reservationDate + "T00:00:00");
  const today = new Date();
  today.setHours(0, 0, 0, 0); // reset giờ

  if (selectedDate <= today) {
    alert("Ngày đặt phải sau ngày hiện tại.");
    return;
  }

  // ✅ Validate phải chọn ít nhất 1 dịch vụ
  if (!formData.selectedServiceIds || formData.selectedServiceIds.length === 0) {
    alert("Vui lòng chọn ít nhất một dịch vụ.");
    return;
  }

  // ✅ Validate staff
  if (!formData.staffId || formData.staffId === 0) {
    alert("Vui lòng chọn nhân viên.");
    return;
  }

  const payload = {
    CustomerId: formData.personId,
    StaffId: formData.staffId,
    ReservationDate: formData.reservationDate?.slice(0, 10),
    Note: formData.note,
    Status: formData.status,
    ServiceIds: formData.selectedServiceIds,
  };

  try {
    const res = await fetch(`https://localhost:7012/api/reservation/${id}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(payload),
    });

    if (!res.ok) throw new Error("Update failed");
    alert("Reservation updated successfully!");
    navigate(`/reservation/detail/${id}`);
  } catch (err) {
    console.error("Update error:", err);
    alert("Update failed.");
  }
};

  if (loading) return <div>Loading...</div>;

  return (
    <div className="p-4 max-w-xl mx-auto bg-white rounded-xl shadow-md space-y-4">
      <h2 className="text-xl font-semibold">Update Reservation</h2>
      <form onSubmit={handleSubmit} className="space-y-4">

        <div>
          <label className="font-medium">Reservation Date:</label>
          <input
            type="date"
            name="reservationDate"
            value={formData.reservationDate}
            onChange={handleChange}
            className="border rounded px-2 py-1 w-full"
          />
        </div>

        <div>
          <label className="font-medium">Note:</label>
          <input
            type="text"
            name="note"
            value={formData.note}
            onChange={handleChange}
            className="border rounded px-2 py-1 w-full"
          />
        </div>

        <div className="flex items-center">
          <input
            type="checkbox"
            name="status"
            checked={formData.status === 1}
            onChange={handleChange}
            className="mr-2"
          />
          <label className="font-medium">Status (Checked = 1)</label>
        </div>

        <div>
          <label className="font-medium">Customer:</label>
          <input
            type="text"
            value={`${formData.customerName} (ID: ${formData.personId})`}
            disabled
            className="border rounded px-2 py-1 w-full bg-gray-100"
          />
        </div>

      <div>
  <label className="font-medium">Staff:</label>
  <select
    name="staffId"
    value={formData.staffId}
    onChange={handleChange}
    className="border rounded px-2 py-1 w-full"
  >
    <option value={0}>-- {getDefaultStaffName()} --</option>
    {allStaffs.map((s) => (
      <option key={`staff-${s.personId}`} value={s.personId}>
        {s.fullName} ({s.personName})
      </option>
    ))}
  </select>
</div>

        <div>
          <h4 className="font-semibold mt-4">Services</h4>
          {allServices.map((s) => (
            <div key={`service-${s.serviceId}`} className="flex items-center mt-2">
              <input
                type="checkbox"
                checked={formData.selectedServiceIds.includes(s.serviceId)}
                onChange={() => handleServiceToggle(s.serviceId)}
                className="mr-2"
              />
              <label>{s.serviceName} (ID: {s.serviceId})</label>
            </div>
          ))}
        </div>

        <button
          type="submit"
          className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
        >
          Update Reservation
        </button>
      </form>
    </div>
  );
}

export default ReservationUpdate;
