import React, { useEffect, useState } from 'react';

function ReservationCreate() {
  const [serviceList, setServiceList] = useState([]);

  const [formData, setFormData] = useState({
    customerId: 1,
    staffId: '',
    reservationDate: '',
    note: '',
    serviceIds: [],
  });

  useEffect(() => {
    fetchServices();
  }, []);

  const fetchServices = async () => {
    try {
      const res = await fetch('https://localhost:7012/api/service/list');
      const data = await res.json();
      console.log('Danh sách dịch vụ:', data);
      setServiceList(data);
    } catch (err) {
      console.error("Lỗi khi lấy dịch vụ:", err);
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
      alert('Vui lòng nhập ID nhân viên hợp lệ');
      return;
    }

    const payload = {
      ...formData,
      staffId: parsedStaffId,
    };

    try {
      const res = await fetch('https://localhost:7012/api/reservation/create', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
      });

      const result = await res.json();
      if (res.ok) {
        alert('Đặt lịch thành công!');
      } else {
        alert('Lỗi: ' + (result.message || 'Tạo thất bại'));
      }
    } catch (error) {
      alert('Lỗi kết nối server');
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
          <label>Nhập ID nhân viên:</label>
          <input
            type="text"
            value={formData.staffId}
            onChange={(e) =>
              setFormData({
                ...formData,
                staffId: e.target.value,
              })
            }
          />
          {formData.staffId && (
            <p style={{ color: 'green' }}>Đã nhập ID: {formData.staffId}</p>
          )}
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
