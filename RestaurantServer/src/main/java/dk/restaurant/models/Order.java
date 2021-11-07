package dk.restaurant.models;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class Order implements Serializable
{
  private long orderId;
  private String status; // Not sure how to make the enums work with JSON and SQL
  private Customer customer;
  private List<Menu> menus;
  private Date orderDate;
  private Date deliveryTime;
  private double price;

  Order() {}

  public Order(long orderId, String status, Customer customer, List<Menu> menus,
      double price, Date orderDate, Date deliveryTime)
  {
    this.orderId = orderId;
    this.orderDate = orderDate;
    this.deliveryTime = deliveryTime;
    this.status = status;
    this.customer = customer;
    this.menus = new ArrayList<Menu>();
    this.price = price;
  }

  public long getOrderId()
  {
    return orderId;
  }

  public void setOrderId(long orderId)
  {
    this.orderId = orderId;
  }

  public double getPrice()
  {
    return price;
  }

  public void setPrice(double price)
  {
    this.price = price;
  }

  public Customer getCustomer()
  {
    return customer;
  }

  public void setCustomer(Customer customer)
  {
    this.customer = customer;
  }

  public List<Menu> getMenus()
  {
    return menus;
  }

  public Date getOrderDate()
  {
    return orderDate;
  }

  public void setOrderDate(Date orderDate)
  {
    this.orderDate = orderDate;
  }

  public Date getDeliveryTime()
  {
    return deliveryTime;
  }

  public void setDeliveryTime(Date deliveryTime)
  {
    this.deliveryTime = deliveryTime;
  }

  public void setMenus(List<Menu> menus)
  {
    this.menus = menus;
  }

  public String getStatus() {
    return this.status;
  }


  public void setStatus(String status) {
    this.status = status;
  }

  @Override public String toString()
  {
    return "Order{" + "order_id=" + orderId +
        ", status=" + status + ", customer=" + customer.getCustomerId() + ", price=" + price + '}';
  }
}