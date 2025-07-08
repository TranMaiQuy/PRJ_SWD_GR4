import React, { useEffect, useState } from 'react';

function ReservationCreate() {
  const [serviceList, setServiceList] = useState([]);
  const [staffList, setStaffList] = useState([]);

  const [formData, setFormData] = useState({
    customerId: 1,
    staffId: '', // staffId chính là personId
    reservationDate: '',
    note: '',
    serviceIds: [],
  });

  useEffect(() => {
    fetchServices();
    fetchStaff();
  }, []);

  const fetchServices = async () => {
    try {
      const res = await fetch('https://localhost:7012/api/service/list');
      const data = await res.json();
      setServiceList(data);
    } catch (err) {
      console.error("Lỗi khi lấy dịch vụ:", err);
    }
  };

  const fetchStaff = async () => {
    try {
      const res = await fetch('https://localhost:7012/api/staff/list');
      const data = await res.json();

      const getStaffName = (id) => {
        switch (id) {
          case 1: return 'Doctor';
          case 2: return 'Nurse';
          default: return 'Unknown';
        }
      };

      const updatedList = data.map((staff) => ({
        ...staff,
        staffName: getStaffName(staff.staffId),
      }));

      setStaffList(updatedList);
    } catch (err) {
      console.error("Lỗi khi lấy danh sách nhân viên:", err);
    }
  };

  const handleCheckboxChange = (serviceId) => {
    const id = parseInt(serviceId);
    setFormData((prev) => {
      const alreadySelected = prev.serviceIds.includes(id);
      return {
        ...prev,
        serviceIds: alreadySelected
          ? prev.serviceIds.filter((itemId) => itemId !== id)
          : [...prev.serviceIds, id],
      };
    });
  };

 const handleSubmit = async (e) => {
  e.preventDefault();

  const parsedStaffId = parseInt(formData.staffId);
  if (isNaN(parsedStaffId)) {
    alert('Vui lòng chọn nhân viên hợp lệ');
    return;
  }

  // ✅ Validate ngày đặt
  if (!formData.reservationDate) {
    alert("Vui lòng chọn ngày đặt");
    return;
  }

  const selectedDate = new Date(formData.reservationDate + "T00:00:00"); // chuẩn hóa để không bị lệch giờ
  const today = new Date();
  today.setHours(0, 0, 0, 0); // reset giờ phút giây

  if (selectedDate <= today) {
    alert("Ngày đặt phải sau hôm nay");
    return;
  }

  // ✅ Validate chọn dịch vụ
  if (!formData.serviceIds || formData.serviceIds.length === 0) {
    alert("Vui lòng chọn ít nhất một dịch vụ");
    return;
  }

  // Gửi payload nếu hợp lệ
  const payload = {
    customerId: formData.customerId,
    staffId: parsedStaffId,
    reservationDate: formData.reservationDate,
    note: formData.note,
    serviceIds: formData.serviceIds,
  };

  try {
    const res = await fetch("https://localhost:7012/api/reservation/create", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(payload),
    });

    const result = await res.json();
    if (res.ok) {
      alert("Đặt lịch thành công!");
    } else {
      alert("Lỗi: " + (result.message || "Tạo thất bại"));
    }
  } catch (error) {
    alert("Lỗi kết nối server");
  }
};

  const getSelectedServices = () => {
    return serviceList.filter((s) =>
      formData.serviceIds.includes(parseInt(s.serviceId))
    );
  };

  return (
    <div>
      <h2>Tạo đặt chỗ mới</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Chọn nhân viên:</label>
          <select
            value={formData.staffId}
            onChange={(e) =>
              setFormData({ ...formData, staffId: e.target.value })
            }
          >
            <option value="">-- Chọn nhân viên --</option>
            {staffList.map((staff) => (
              <option key={staff.personId} value={staff.personId}>
                {staff.staffName} (ID: {staff.staffId}) - {staff.personName}
              </option>
            ))}
          </select>
        </div>

        <div>
          <label>Ngày đặt:</label>
          <input
            type="date"
            value={formData.reservationDate}
            onChange={(e) =>
              setFormData({ ...formData, reservationDate: e.target.value })
            }
          />
        </div>

        <div>
          <label>Ghi chú:</label>
          <textarea
            value={formData.note}
            onChange={(e) => setFormData({ ...formData, note: e.target.value })}
          />
        </div>

        <div>
          <label>Chọn dịch vụ:</label>
          {serviceList.map((service, index) => (
            <div key={service.serviceId || index}>
              <label>
                <input
                  type="checkbox"
                  checked={formData.serviceIds.includes(parseInt(service.serviceId))}
                  onChange={() => handleCheckboxChange(service.serviceId)}
                />
                {service.serviceName} (ID: {service.serviceId})
              </label>
            </div>
          ))}
        </div>

        {formData.serviceIds.length > 0 && (
          <div>
            <h4>Dịch vụ đã chọn:</h4>
            <ul>
              {getSelectedServices().map((s, index) => (
                <li key={s.serviceId || index}>
                  {s.serviceName} (ID: {s.serviceId})
                </li>
              ))}
            </ul>
          </div>
        )}

        <button type="submit">Tạo đặt chỗ</button>
      </form>
    </div>
  );
}

export default ReservationCreate;

